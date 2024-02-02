// Exceeding requirements:

// 1) Added Menu Class
// 2) User answers in Listing Activity saved and displayed using animation

using System;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        
        while (menu.GetSelectedMenuItem() != 4)
        {
            menu.DisplayMenu();

            switch (menu.GetSelectedMenuItem())
            {
                case 1 :
                    menu.StartBreathingActivity();
                    break;
                case 2 :
                    menu.StartReflectingActivity();
                    break;
                case 3 :
                    menu.StartListingActivity();
                    break;
                default:
                    break;
            }
        }
    }
}