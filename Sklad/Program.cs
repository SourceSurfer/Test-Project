using System;
using System.Globalization;
using System.Linq;

namespace Sklad
{
    internal class Program
    {
        protected const string EMPTY = "Не корректное значение ";
        private const string COUNT = "Введите количество ";
        private const string WIDTHMSG = "Введите ширину ";
        private const string HEIGHTMSG = "Введите высоту ";
        private const string DEPTHMSG = "Введите глубину ";
        private const string BESTBEFOREDATEMSG = "Срок годности ";
        private const string DATEOFMANUFACTURE = "Дата производства ";
        private const string WEIGHTMSG = "Введите вес ";

        private static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в программу склад");

            Palet[] palet;
            {
                var paletCount = GetDataForPalet(COUNT + "палетов: ");
                palet = new Palet[paletCount];

                // Заполняем палет данными
                for (var i = 0; i < paletCount; i++)
                {
                    palet[i] = new Palet
                    {
                        ID = i,
                        Width = GetDataForPalet($"{WIDTHMSG} {i+1}го палета: "),
                        Height = GetDataForPalet($"{HEIGHTMSG} {i+1}го палета: "),
                        Depth = GetDataForPalet($"{DEPTHMSG} {i+1}го палета: ")
                    };

                    // Собираем коробки для палета
                    var paletKorobki = Array.Empty<Korobka>();
                    {

                        var countKorobok = GetDataForPalet(COUNT + "коробок: ");

                        paletKorobki = new Korobka[countKorobok];

                        // Заполняем коробки для палета
                        for (var y = 0; y < paletKorobki.Length; y++)
                        {
                            paletKorobki[y] = new Korobka
                            {
                                ID = y,
                                Width = GetDataForKorobka($"{WIDTHMSG} {y + 1}й коробки: ", palet[i].Width),
                                Height = GetDataForPalet($"{HEIGHTMSG} {y + 1}й коробки: "),
                                Depth = GetDataForKorobka($"{DEPTHMSG} {y + 1}й коробки: ", palet[i].Depth),
                                Weight = GetDataForPalet($"{WEIGHTMSG} {y + 1}й коробки: "),
                                
                            };

                            paletKorobki[y].Volume =
                                paletKorobki[y].Width * paletKorobki[y].Height * paletKorobki[y].Depth;


                            #region Срок годности и дата производства

                            var input = string.Empty;

                            var validInput = false;
                            while (!validInput)
                            {
                                Console.Write(
                                    $"Для ввода {BESTBEFOREDATEMSG} коробки нажмите 0, для ввода {DATEOFMANUFACTURE} коробки нажмите 1: ");
                                input = Console.ReadLine();

                                if (input == string.Empty || (input != "0" && input != "1"))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(EMPTY);
                                    Console.ResetColor();
                                }
                                else
                                {
                                    validInput = true;
                                }
                            }

                            switch (input)
                            {
                                case "0":
                                    var bestBeforeDate =
                                        GetDateTime($"{BESTBEFOREDATEMSG} коробки в формате DD.MM.YYYY: ");
                                    paletKorobki[y].BestBeforeDate = bestBeforeDate;
                                    break;

                                case "1":
                                    var manufactureDate =
                                        GetDateTime($"{DATEOFMANUFACTURE} коробки в формате DD.MM.YYYY: ");
                                    paletKorobki[y].DateOfManufacture = manufactureDate;
                                    break;
                            }

                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine(new string('*', 50));
                            Console.ResetColor();

                            #endregion



                        }

                    }

                    // Сохраняем на палете коробки
                    palet[i].korobki = paletKorobki;
                    palet[i].CountDateOfManufacture(paletKorobki.Min(entity => entity.BestBeforeDate));
                    palet[i].WeightPalet(paletKorobki.Sum(entity => entity.Weight));
                    palet[i].CountPaletVolume(paletKorobki.Sum(entity => entity.Volume));

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(new string('*', 50));
                    Console.ResetColor();
                }
                Console.WriteLine();
            }


            // Список всех коробок на всех палетах
            Console.WriteLine($"Список всех палет и коробок");

            foreach (var VARIABLE in palet)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"ID Paleta {VARIABLE.ID + 1}".PadRight(10));
                foreach (var korobka in VARIABLE.korobki)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine($"ID korobki {korobka.ID + 1}".PadRight(15));
                }
                Console.ResetColor();
            }

            #region Сгруппировать палеты по сроку годности
            // TODO не сделана группировка по сроку годности
           /*
            var groupPaletDateBefor = palet.GroupBy(item => item.BestBeforeDate);

            foreach (var group in groupPaletDateBefor)
            {
                Console.WriteLine($"Group: {group.Key}");

                foreach (var item in group)
                {
                    Console.WriteLine($"Palet ID: {item.ID}, BestBeforeDate: {item.BestBeforeDate}");
                }

                Console.WriteLine();
            }*/
            #endregion

            #region Отсортировать по возрастанию срока годности

            Console.WriteLine("Сортировка по возрастанию срока годности");
            var sortPaletByBestBeforeDate = palet.OrderBy(item => item.BestBeforeDate);
            foreach (var item in sortPaletByBestBeforeDate)
            {
                Console.WriteLine($"Id PALETA: {item.ID}, Date: {item.BestBeforeDate}");
            }


            #endregion

            Console.WriteLine();
            #region Отсортировать палеты по весу

            Console.WriteLine("Сортировка по весу");
            var sortPaletByWeight = palet.OrderBy(item => item.Weight);
            foreach (var item in sortPaletByWeight)
            {
                Console.WriteLine($"Id PALETA: {item.ID}, Date: {item.BestBeforeDate}");
            }

            #endregion
            Console.ReadKey();
        }

        /// <summary>
        /// Проверяет правильность ввода и возвращает значение
        /// </summary>
        /// <param name="message">Сообщение для пользователя</param>
        /// <returns>Значение</returns>
        public static int GetDataForPalet(string message)
        {
            var validInput = false;
            var value = 0;

            while (!validInput)
            {
                Console.Write($"  {message}");
                var input = Console.ReadLine();

                if (!int.TryParse(input, out value) || value == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(EMPTY);
                    Console.ResetColor();
                }
                else
                {
                    validInput = true;
                }
            }

            Console.WriteLine(new string('*', 50));
            return value;
        }

        /// <summary>
        /// Возвращает ширину или глубину коробки
        /// </summary>
        /// <param name="message">Сообщение для пользователя</param>
        /// <param name="paletWidth">Ширина или глубина палета</param>
        /// <returns></returns>
        public static int GetDataForKorobka(string message, int paletWidth)
        {
            while (true)
            {
                Console.Write($"  {message}");
                var strWidth = Console.ReadLine();
                if (strWidth == string.Empty || !int.TryParse(strWidth, out var value) || value == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(EMPTY);
                    Console.ResetColor();
                }
                else
                {
                    value = int.Parse(strWidth);

                    if (value == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(EMPTY);
                        Console.ResetColor();
                    }
                    else if (value > paletWidth)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Ширина коробки не может быть больше ширины палета {paletWidth}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(new string('*', 50));
                        return value;
                    }
                }
            }
        }

        /// <summary>
        /// Возвращает дату производства или срок годности
        /// </summary>
        /// <param name="message">Сообщение пользователю</param>
        /// <returns></returns>
        public static DateTime GetDateTime(string message)
        {
            var validInput = false;
            var value = DateTime.Now;

            while (!validInput)
            {
                Console.Write(message.PadRight(10));
                var input = Console.ReadLine();

                if (!DateTime.TryParseExact(input, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                        out value))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(EMPTY);
                    Console.ResetColor();
                }
                else
                {
                    validInput = true;
                }
            }

            return value;
        }
    }
}