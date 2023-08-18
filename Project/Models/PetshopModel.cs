namespace Teste_Pratico_DTI.Models
{
    public class PetshopModel
    {
        private string nome;
        private double precoCachorroPequeno;
        private double precoCachorroGrande;
        private double distancia; 

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public double PrecoCachorroPequeno
        {
            get { return precoCachorroPequeno; }
            set { precoCachorroPequeno = value; }
        }

        public double PrecoCachorroGrande
        {
            get { return precoCachorroGrande; }
            set { precoCachorroGrande = value; }
        }

        public double Distancia 
        {
            get { return distancia; }
            set { distancia = value; }
        }
    }
}
