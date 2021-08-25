using System;

namespace dotnet_proj01
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while(userOption.ToUpper() != "X") {
                switch(userOption) {
                    case "1":
                        ListSeries(); break;
                    case "2":
                        InsertSerie(); break;
                    case "3":
                        UpdateSerie(); break;
                    case "4":
                        DeleteSerie(); break;
                    case "5":
                        ViewSerie(); break;
                    case "C":
                        Console.Clear(); break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                userOption = GetUserOption();
            }
            Console.WriteLine("Thank you for using our service!");
            Console.ReadLine();
        }

        public static string GetUserOption() {
            Console.WriteLine();
            Console.WriteLine("Somethingsomething Series");
            Console.WriteLine("Select your action");
            
            Console.WriteLine("1 - List Series");
            Console.WriteLine("2 - Insert a new Serie");
            Console.WriteLine("3 - Update a Serie");
            Console.WriteLine("4 - Delete a Serie");
            Console.WriteLine("5 - View a Serie");
            Console.WriteLine("C - Clear screen");
            Console.WriteLine("X - Exit");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }

        private static void ListSeries() {
            var list = repository.List();
            
            Console.WriteLine("List available Series");
            if(list.Count == 0) {
                Console.WriteLine("No Series available");
                return;
            }
            foreach(var serie in list) {
                var deleted = serie.GetDeleted();
                Console.WriteLine("#ID {0}: {1}{2}", serie.GetId(), serie.GetTitle(), (deleted ? " *No longer available*" : ""));
            }
        }

        private static void InsertSerie() {
            Console.WriteLine("Insert a new Serie");

            foreach(int i in Enum.GetValues(typeof(Genre))) {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.WriteLine("Type the genre code: ");
            int genreInput = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the serie's title: ");
            string titleInput = Console.ReadLine();
            Console.WriteLine("Enter the year the show first aired: ");
            int yearInput = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a description for this show: ");
            string descriptionInput = Console.ReadLine();

            Serie newSerie = new Serie(id: repository.NextId(), 
                                        genre: (Genre)genreInput, 
                                        title: titleInput, 
                                        year: yearInput, 
                                        description: descriptionInput);
            repository.Insert(newSerie);
        }

        private static void UpdateSerie() {
			Console.Write("Type the serie's code");
			int serieId = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genre)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
			}
			Console.Write("Enter the genre option among the options above: ");
			int genreInput = int.Parse(Console.ReadLine());

			Console.Write("Enter the serie's title: ");
			string titleInput = Console.ReadLine();

			Console.Write("Enter the year the show first aired: ");
			int yearInput = int.Parse(Console.ReadLine());

			Console.Write("Enter a description for this show: ");
			string descriptionInput = Console.ReadLine();

			Serie updateSerie = new Serie(id: serieId,
										genre: (Genre)genreInput,
										title: titleInput,
										year: yearInput,
										description: descriptionInput);

			repository.Update(serieId, updateSerie);
		}

        private static void DeleteSerie() {
			Console.Write("Type the serie's code: ");
			int serieId = int.Parse(Console.ReadLine());

			repository.Delete(serieId);
		}

        private static void ViewSerie() {
			Console.Write("Type the serie's code: ");
			int serieId = int.Parse(Console.ReadLine());
			var serie = repository.ReturnById(serieId);
			Console.WriteLine(serie);
		}
    }
}
