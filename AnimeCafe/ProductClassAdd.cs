using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeCafe
{
    public class ProductClassAdd
    {
        public string NameProduct {  get; set; }
        public string Type {  get; set; }
        public int KolProduct { get; set; }
        public double CostProduct {  get; set; }
        public int DeleteId {  get; set; }
        public int ChangeId { get; set; } 
        public int DobPlusId {  get; set; }
        public int DobMinusId { get;set; }
        public int KolProdAfterClick { get; set; }
        public int AddInBaskId {  get; set; }
        public bool CheckedButton { get; set; }
        public string fileName { get; set; }
        public Bitmap ProductImage
        {
            get
            {
                return new Bitmap(fileName);
            }
            set { }
        }

    }
}
