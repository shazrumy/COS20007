using System;
using System.IO;  // ADDED: Required for StreamWriter/StreamReader

namespace SwinAdventure
{
    public abstract class GameObject : IdentifiableObject
    {
        private string _name;
        private string _description;

        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            _name = name;
            _description = desc;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public virtual string ShortDescription  // FIXED: Made virtual so Item can override
        {
            get
            {
                return Name + " (" + FirstID + ")";  // FIXED: Changed FirstId to FirstID
            }
        }

        public virtual string FullDescription
        {
            get
            {
                return _description;
            } 
        }

        public virtual void SaveTo(StreamWriter writer)
        {
            //read the GameObject's name from the file
            writer.WriteLine(_name);
            //save the GameObject's description into the file as well
            writer.WriteLine(_description);
        }

        public virtual void LoadFrom(StreamReader reader)
        {
            //read the GameObject's name from the file
            _name = reader.ReadLine() ?? "";  // FIXED: Added null safety
            //read the GameObject's description from the file as well
            _description = reader.ReadLine() ?? "";  // FIXED: Added null safety
        }
    }
}
