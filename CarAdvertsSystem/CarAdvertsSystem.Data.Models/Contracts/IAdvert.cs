using CarAdvertsSystem.Data.Models.Enums;

namespace CarAdvertsSystem.Data.Models.Contracts
{
    public interface IAdvert
    {
        City City { get; set; }
        int CityId { get; set; }
        ColorType Color { get; set; }
        string Description { get; set; }
        int DistanceCoverage { get; set; }
        EngineType EngineType { get; set; }
        int EngineVolume { get; set; }
        int Id { get; set; }
        bool IsDeleted { get; set; }
        int Power { get; set; }
        decimal Price { get; set; }
        string Title { get; set; }
        TransmissionType TransmissionType { get; set; }
        User User { get; set; }
        int UserlId { get; set; }
        VethicleModel VethicleModel { get; set; }
        int VethicleModelId { get; set; }
        int Year { get; set; }
    }
}