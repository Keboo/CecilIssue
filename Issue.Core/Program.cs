﻿using System;
using System.Linq;
using System.Reflection;
using Mono.Cecil;

namespace Issue.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            var actionType = typeof(Action<int>);
            var ctor = actionType.GetConstructors().First();
            var module = ModuleDefinition.ReadModule(Assembly.GetEntryAssembly().Location);
            //This line throws NotImplementedException
            MethodReference def = module.ImportReference(ctor);
            if (def != null)
            {
                Console.WriteLine("Imported reference");
            }
            Console.ReadLine();
        }
    }
}
