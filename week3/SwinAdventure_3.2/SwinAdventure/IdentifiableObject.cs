using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IdentifiableObject
{
    // Object that can be identified by multiple string identifiers
    public class IdentifiableObject
    {
        // List to store identifiers in lowercase
        private List<string> _identifiers;

        // Constructor - adds identifiers from array
        public IdentifiableObject(string[] idents)
        {
            _identifiers = new List<string>();
            for (int i = 0; i < idents.Length; i++)
            {
                _identifiers.Add(idents[i].ToLower());
            }
        }

        // Checks if this object matches the given identifier
        public bool AreYou(string id)
        {
            return _identifiers.Contains(id.ToLower());
        }

        // Returns first identifier or empty string if none exist
        public string FirstID
        {
            get
            {
                if (_identifiers.Count == 0)
                {
                    return "";
                }
                else
                {
                    return _identifiers.First();
                }
            }
        }

        // Adds new identifier to the list
        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }

        // Checks pin against student ID, replaces first identifier if match
        public void PrivilegeEscalation(string pin)
        {
            string studentIdLast4 = "0247"; // Last 4 digits of student ID: 104100247
            
            if (pin == studentIdLast4)
            {
                if (_identifiers.Count > 0)
                {
                    _identifiers[0] = "tutorial_id"; // Replace with actual tutorial ID
                }
            }
        }

        // Removes identifier from the list if it exists
        public void RemoveIdentifier(string id)
        {
            _identifiers.Remove(id.ToLower());
        }
    }
}
