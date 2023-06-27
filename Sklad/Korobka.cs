using System;

namespace Sklad
{
    internal class Korobka : SkladObjects
    {
        public override int ID { get; set; }
        public override int Width { get; set; }
        public override int Height { get; set; }
        public override int Depth { get; set; }
        public override int Weight { get; set; }
        public override DateTime BestBeforeDate { get; set; }


        public override DateTime DateOfManufacture
        {
            get => date_Of_Manufacture;
            set
            {
                date_Of_Manufacture = value;
                CountDateOfManufacture(value);
            }
        }

        public override int Volume
        {
            get => volume;
            set => volume = value;
        }

        private void CountDateOfManufacture(DateTime dateManufacture)
        {
            BestBeforeDate = dateManufacture.AddDays(100);
        }
    }
}