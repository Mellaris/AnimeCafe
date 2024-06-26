using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeCafe
{
    public class RegistrClassAccount
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public int BonusBall {  get; set; }
        public string fileName {  get; set; }
        public bool newF = true;

        public List<ProductClassAdd> productsBasket = new List<ProductClassAdd>();
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
