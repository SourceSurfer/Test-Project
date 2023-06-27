using System;

namespace Sklad
{
    internal class Palet : SkladObjects
    {
        public override int ID { get; set; }

        /// <summary>
        ///     Ширина палета
        /// </summary>
        public override int Width { get; set; }

        /// <summary>
        ///     Высота палета
        /// </summary>
        public override int Height { get; set; }

        /// <summary>
        ///     Глубина палет
        /// </summary>
        public override int Depth { get; set; }

        /// <summary>
        ///     Вес палета
        /// </summary>
        public override int Weight { get; set; }

        /// <summary>
        ///     Срок годности палета
        /// </summary>
        public override DateTime BestBeforeDate { get; set; }

        public override DateTime DateOfManufacture
        {
            get => date_Of_Manufacture;
            set => date_Of_Manufacture = value;
        }

        /// <summary>
        ///     Массив всех коробок на палете
        /// </summary>
        public Korobka[] korobki { get; set; }

        /// <summary>
        ///     Объем палета
        /// </summary>
        public override int Volume
        {
            get => volume;
            set => volume = value;
        }


        /// <summary>
        ///     Срок годности палета
        /// </summary>
        /// <param name="dateManufacture">Наименьший срок годности коробки</param>
        public void CountDateOfManufacture(DateTime dateManufacture)
        {
            BestBeforeDate = dateManufacture;
        }


        /// <summary>
        ///     Вес палета
        /// </summary>
        /// <param name="sumKorobki">Сумма веса всех коробок</param>
        public void WeightPalet(int sumKorobki)
        {
            Weight = sumKorobki + 30;
        }

        /// <summary>
        ///     Объем палета
        /// </summary>
        /// <param name="sum">Сумма всех коробок на палете</param>
        internal void CountPaletVolume(int sum)
        {
            Volume = sum + Width * Height * Depth;
        }
    }
}