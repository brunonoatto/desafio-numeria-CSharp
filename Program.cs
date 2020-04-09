using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace DesafioNumeria
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = GetItems();
            var service = new ElevadorService(items);

            Console.WriteLine("andarMenosUtilizado={0}", string.Join(",", service.andarMenosUtilizado()));
            Console.WriteLine("elevadorMaisFrequentado={0}", string.Join(",", service.elevadorMaisFrequentado()));
            Console.WriteLine("elevadorMenosFrequentado={0}", string.Join(",", service.elevadorMenosFrequentado()));
            Console.WriteLine("percentualDeUsoElevadorA={0}", string.Join(",", service.percentualDeUsoElevadorA()));
            Console.WriteLine("percentualDeUsoElevadorB={0}", string.Join(",", service.percentualDeUsoElevadorB()));
            Console.WriteLine("percentualDeUsoElevadorC={0}", string.Join(",", service.percentualDeUsoElevadorC()));
            Console.WriteLine("percentualDeUsoElevadorD={0}", string.Join(",", service.percentualDeUsoElevadorD()));
            Console.WriteLine("percentualDeUsoElevadorE={0}", string.Join(",", service.percentualDeUsoElevadorE()));
            Console.WriteLine("periodoMaiorFluxoElevadorMaisFrequentado={0}", string.Join(",", service.periodoMaiorFluxoElevadorMaisFrequentado()));
            Console.WriteLine("periodoMaiorUtilizacaoConjuntoElevadores={0}", string.Join(",", service.periodoMaiorUtilizacaoConjuntoElevadores()));
            Console.WriteLine("periodoMenorFluxoElevadorMenosFrequentado={0}", string.Join(",", service.periodoMenorFluxoElevadorMenosFrequentado()));
            Console.Read();
        }

        private static List<InputItem> GetItems()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var jsonString = File.ReadAllBytes("input.json");
            List<InputItem> items = JsonSerializer.Deserialize<List<InputItem>>(jsonString, options);

            return items;
        }
    }
}
