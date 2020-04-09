using System.Collections.Generic;
using System.Linq;

namespace DesafioNumeria
{
    public class ElevadorService : IElevadorService
    {
        private List<InputItem> Items;
        public ElevadorService(List<InputItem> items)
        {
            Items = items;
        }

        public List<int> andarMenosUtilizado()
        {
            return Items.GroupBy(o => o.Andar)
                .OrderBy(o => o.Count())
                .Select(o => o.First().Andar)
                .ToList();
        }

        public List<char> elevadorMaisFrequentado()
        {
            return Items.GroupBy(o => o.Elevador)
                .OrderByDescending(o => o.Count())
                .Select(o => o.First().Elevador)
                .ToList();
        }

        public List<char> elevadorMenosFrequentado()
        {
            return Items.GroupBy(o => o.Elevador)
                .OrderBy(o => o.Count())
                .Select(o => o.First().Elevador)
                .ToList();
        }

        private float GetPercental(char elevador)
        {
            float total = Items.Count();
            float totalElevadorA = Items.Where(o => o.Elevador == elevador).Count();
            return totalElevadorA * 100 / total;
        }

        public float percentualDeUsoElevadorA()
        {
            return GetPercental('A');
        }

        public float percentualDeUsoElevadorB()
        {
            return GetPercental('B');
        }

        public float percentualDeUsoElevadorC()
        {
            return GetPercental('C');
        }

        public float percentualDeUsoElevadorD()
        {
            return GetPercental('D');
        }

        public float percentualDeUsoElevadorE()
        {
            return GetPercental('E');
        }

        public List<char> periodoMaiorFluxoElevadorMaisFrequentado()
        {
            var maisFrequentado = elevadorMaisFrequentado().First();
            return Items.Where(o => o.Elevador == maisFrequentado)
                .GroupBy(o => o.Turno)
                .OrderByDescending(o => o.Count())
                .Select(o => o.First().Turno)
                .ToList();
        }

        public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
        {
            return Items.GroupBy(o => o.Turno)
                .OrderByDescending(o => o.Count())
                .Select(o => o.First().Turno)
                .ToList();
        }

        public List<char> periodoMenorFluxoElevadorMenosFrequentado()
        {
            var menosFrequentado = elevadorMenosFrequentado().First();
            return Items.Where(o => o.Elevador == menosFrequentado)
                .GroupBy(o => o.Turno)
                .OrderBy(o => o.Count())
                .Select(o => o.First().Turno)
                .ToList();
        }
    }
}