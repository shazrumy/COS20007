using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;  // ADDED for file operations

namespace SwinAdventure
{
    // Abstract base class for anything the player can interact with
    public abstract class GameObject : IdentifiableObject
    {
        // Private fields to store object properties
        private string _description, _name;

        // Constructor - creates game object with identifiers, name, and description
        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            _name = name;
            _description = desc;
        }

        // Read-only property that returns the object's name
        public string Name
        {
            get
            {
                return _name;
            }
        }

        // Virtual property for full description - can be overridden by child classes
        public virtual string FullDescription
        {
            get
            {
                return _description;
            }
        }

        // Virtual property for brief description - can be overridden by child classes  
        public virtual string ShortDescription
        {
            get
            {
                return $"{_name} ({FirstID})";
            }
        }

        // STEP 12: Add these two methods exactly as shown in PDF
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
            _name = reader.ReadLine() ?? "";
            //read the GameObject's description from the file as well  
            _description = reader.ReadLine() ?? "";
        }
    }
}
