﻿using CommandLine;
using CommandLine.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Generic;

namespace NoAccessibleCompiler
{
    /// <summary>
    /// Command line options.
    /// </summary>
    public class Options
    {
        /// <summary>
        /// Output path.
        /// </summary>
        [Option('o', "out", Required = true, HelpText = "Output path.")]
        public string Out { get; set; }

        /// <summary>
        /// Target assembly names separated by semicolons to access internally.
        /// </summary>
        [Option('a', "assemblyNames", Required = false, Separator = ';', HelpText = "Target assembly names separated by semicolons to access internally")]
        public IEnumerable<string> AssemblyNames { get; set; }

        /// <summary>
        /// Configuration.
        /// </summary>
        [Option('c', "configuration", Required = false, Default = OptimizationLevel.Release, HelpText = "Configuration <Release|Debug>")]
        public OptimizationLevel Configuration { get; set; }

        /// <summary>
        /// Logfile path.
        /// </summary>
        [Option('l', "logfile", Required = false, Default = "compile.log", HelpText = "Logfile path")]
        public string Logfile { get; set; }

        /// <summary>
        /// Input source code path (*.cs)
        /// </summary>
        [Value(1, MetaName = "InputPaths", HelpText = "Input source code path (*.cs)")]
        public IEnumerable<string> InputPaths { get; set; }

        /// <summary>
        /// Referenced assembly paths
        /// </summary>
        [Option('r', "reference", Required = false, Separator = ';', HelpText = "Referenced assemblies separated by semicolons")]
        public IEnumerable<string> References { get; set; }

        /// <summary>
        /// Define symbols.
        /// </summary>
        [Option('d', "define", Required = false, Separator = ';', HelpText = "Define symbols separated by semicolons")]
        public IEnumerable<string> Defines { get; set; }

        /// <summary>
        /// Allow unsafe code.
        /// </summary>
        [Option("unsafe", Required = false, Default = false, HelpText = "Allow unsafe code")]
        public bool Unsafe { get; set; }

        /// <summary>
        /// Target output kind.
        /// </summary>
        [Option('t', "target", Required = false, Default = OutputKind.DynamicallyLinkedLibrary, HelpText = "Target output kind. <DynamicallyLinkedLibrary|ConsoleApplication|NetModule>")]
        public OutputKind Target { get; set; }

        /// <summary>
        /// C# language version.
        /// </summary>
        [Option('l', "langage", Required = false, Default = LanguageVersion.Latest, HelpText = "C# language version. <CSharp1|...|CSharp7|CSharp7_1|CSharp7_2|CSharp7_3|CSharp8|Latest>")]
        public LanguageVersion LanguageVersion { get; set; }

        /// <summary>
        /// Usages.
        /// </summary>
        [Usage(ApplicationAlias = "InternalAccessibleCompiler")]
        public static IEnumerable<Example> Examples
        {
            get
            {
                return new List<Example>() {
                    new Example("Compile your project to internal accessible dll", new Options { Out = "your.dll", InputPaths = new []{"your.csproj" } })
                };
            }
        }
    }
}