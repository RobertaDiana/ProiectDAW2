using Demo.Models.DTOs.Produs;

namespace ProiectDAW2.Servicies
{
    public interface IProduseServicies
    {
        Task<List<ProdusDto>> GetAllProduse();
        Task<List<ProdusCuProducatorDto>> GetProduseInTermenCuProducatori();
        Task<List<NrProduseProducatoriDTO>> GetCantitateProducatori();
        Task AddProduse(ProdusDto newProduse);
        Task UpdateProdus(UpdateProdusDto updateProdus);
        Task DeleteProduse(Guid produseId);
    }
}
