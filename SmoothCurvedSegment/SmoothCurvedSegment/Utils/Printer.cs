using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SmoothCurvedSegment.Utils
{
    public static class Printer
    {
        static Printer()
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new JsonStringEnumConverter());
            Options = options;
        }

        private static JsonSerializerOptions Options { get; set; }

        public static void Dump<T>(this T data)
        {
            var color = Console.ForegroundColor;
            string representation = JsonSerializer.Serialize(data, Options);
            Trace.WriteLine(representation);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(representation);
            Console.ForegroundColor = color;
        }
    }
}
