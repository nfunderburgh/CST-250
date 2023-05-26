using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HeroMaker
{
    public class SuperHero
    {
        private String name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private ArrayList abilities;
        public ArrayList Abilities
        {
            get { return abilities; }
            set { abilities = value; }
        }

        private String birthday;
        public String Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        private String superPowerDiscovery;
        public String SuperPowerDiscovery
        {
            get { return superPowerDiscovery; }
            set { superPowerDiscovery = value; }
        }

        private String fatefulDay;
        public String FatefulDay
        {
            get { return fatefulDay; }
            set { fatefulDay = value; }
        }

        private String officeLocation;
        public String OfficeLocation
        {
            get { return officeLocation; }
            set { officeLocation = value; }
        }

        private String transportation;
        public String Transportation
        {
            get { return transportation; }
            set
            {
                transportation = value;
            }
        }

        private int speed;
        public int Speed
        {
            get { return speed; }
            set
            {
                speed = value;
            }
        }

        private int yearsExperience;
        public int YearsExperience
        {
            get { return yearsExperience; }
            set { yearsExperience = value; }
        }

        private String color;
        public String Color
        {
            get { return color; }
            set { color = value; }
        }

        private int stamina;
        public int Stamina
        {
            get { return stamina; }
            set { stamina = value; }
        }
        private int strength;
        public int Strength
        {
            get { return strength; }
            set
            { strength = value; }
        }
        private int darkSidePropensity;
        public int DarkSidePropensity
        {
            get { return darkSidePropensity; }
            set
            { darkSidePropensity = value; }
        }
    }
}
