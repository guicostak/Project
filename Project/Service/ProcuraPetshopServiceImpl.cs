using System.Runtime.InteropServices.ObjectiveC;
using Teste_Pratico_DTI.Models;

namespace Project.Service
{
    public class ProcuraPetshopServiceImpl : PetshopService
    {
        public object procuraPetshop(PetshopRequestModel request, int cachorrosGrandes, int cachorrosPequenos, DateTime data)
        {
            double valorTotal;
            string nome;
         

            cachorrosGrandes = request.CachorrosGrandes;
            cachorrosPequenos = request.CachorrosPequenos;

            var diaUtil = definirDiaUtil(request.Data);

            List<PetshopModel> petshops = new List<PetshopModel>
        {
            new PetshopModel { Nome = "Meu Canino Feliz", PrecoCachorroPequeno = 20.0, PrecoCachorroGrande = 40.0, Distancia = 2.0 },
            new PetshopModel { Nome = "Vai Rex", PrecoCachorroPequeno = 15.0, PrecoCachorroGrande = 50.0, Distancia = 1.7 },
            new PetshopModel { Nome = "ChowChawgas", PrecoCachorroPequeno = 30.0, PrecoCachorroGrande = 45.0, Distancia = 0.8 }
        };

            calculaPrecoPorCachorro(petshops, diaUtil);

            var resultado = CalculaMelhorPetshop(petshops, request.CachorrosGrandes, request.CachorrosPequenos);

            var result = new
            {
                ValorTotal = resultado.ValorTotal,
                NomePetshop = resultado.NomePetshop
            };

            return result;
        }

        private static CalculatedResultado CalculaMelhorPetshop(List<PetshopModel> petshops, int cachorrosGrandes, int cachorrosPequenos)
        {
            double valorTotal = double.MaxValue;
            string nomePetshop = "";
            int selectedIndex = 0;

            try
            {
                for (int i = 0; i < petshops.Count; i++)
                {
                    double valorAtual = (cachorrosGrandes * petshops[i].PrecoCachorroGrande) + (cachorrosPequenos * petshops[i].PrecoCachorroPequeno);

                    if (valorAtual < valorTotal || (valorAtual == valorTotal && petshops[i].Distancia < petshops[selectedIndex].Distancia))
                    {
                        valorTotal = valorAtual;
                        nomePetshop = petshops[i].Nome;
                        selectedIndex = i;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção durante o cálculo: {ex.Message}");               
            }

            return new CalculatedResultado
            {
                ValorTotal = valorTotal,
                NomePetshop = nomePetshop
            };
        }

        private static void calculaPrecoPorCachorro(List<PetshopModel> petshops, bool diaUtil)
        {
            try
            {
                foreach (var petshop in petshops)
                {
                    if (!diaUtil)
                    {
                        if (petshop.Nome == "Meu Canino Feliz")
                        {
                            petshop.PrecoCachorroPequeno = petshop.PrecoCachorroPequeno * 1.2;
                            petshop.PrecoCachorroGrande = petshop.PrecoCachorroGrande * 1.2;
                        }
                        else if (petshop.Nome == "Vai Rex")
                        {
                            petshop.PrecoCachorroPequeno = petshop.PrecoCachorroPequeno + 5.0;
                            petshop.PrecoCachorroGrande = petshop.PrecoCachorroGrande + 5.0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção durante o cálculo dos preços: {ex.Message}");
            }
        }


        private bool definirDiaUtil(DateTime data)
        {
            try
            {
                DayOfWeek diaSemana = data.DayOfWeek;
                bool diaUtil = diaSemana >= DayOfWeek.Monday && diaSemana <= DayOfWeek.Friday;

                return diaUtil;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção ao definir o dia útil: {ex.Message}");
                return false;
            }
        }
    }
}
