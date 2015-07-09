using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFinder
{
     public class Map
    {
         public Map(int width, int height)
         {
             _height = height;
             _width = width;
         }

         public int Height 
         { 
             get 
             { 
                 return _height;
             }
         }
         
         public int Width 
         {
             get
             {
                 return _width; 
             } 
         }

         private int _height;
         private int _width;
    }
}
