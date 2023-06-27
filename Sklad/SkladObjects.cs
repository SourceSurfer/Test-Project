using System;

namespace Sklad
{
    /// <summary>
    ///     Базовый класс для объекта Коробка и Палет
    /// </summary>
    internal abstract class SkladObjects
    {
        protected DateTime best_before_date; // срок годности
        protected DateTime date_Of_Manufacture; // дата производства
        protected int depth; // глубина
        protected int height; // высота
        protected int id;
        protected int volume; // Объем
        protected int weight; // вес
        protected int width; // ширина


        /// <summary>
        ///     ID объекта
        /// </summary>
        public abstract int ID { get; set; }

        /// <summary>
        ///     Ширина
        /// </summary>
        public abstract int Width { get; set; }

        /// <summary>
        ///     Высота
        /// </summary>
        public abstract int Height { get; set; }

        /// <summary>
        ///     Глубина
        /// </summary>
        public abstract int Depth { get; set; }

        /// <summary>
        ///     Вес
        /// </summary>
        public abstract int Weight { get; set; }

        /// <summary>
        ///     Срок годности
        /// </summary>
        public abstract DateTime BestBeforeDate { get; set; }

        public abstract DateTime DateOfManufacture { get; set; }

        /// <summary>
        ///     Объем
        /// </summary>
        public abstract int Volume { get; set; }

        /// <summary>
        ///     Считает срок годности если указана дата производсва
        /// </summary>
        /// <returns>значение формата DD.MM.YYYY</returns>
        private void CountDateOfManufacture(DateTime dateManufacture)
        {
            throw new NotImplementedException();
        }
    }
}