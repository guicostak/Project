using Teste_Pratico_DTI.Models;

namespace Project.Service
{
    public interface PetshopService
    {

        object procuraPetshop(PetshopRequestModel request, int cachorrosGrandes, int cachorrosPequenos, DateTime data);

    }
}
