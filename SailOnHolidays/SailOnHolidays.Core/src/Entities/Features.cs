namespace SailOnHolidays.Core.src.Entities
{
    public class Features : BaseEntity
    {
        public Guid YachtIdForFeatures { get; set; }
        public bool AirAconditioning { get; set; }
        public bool Autopilot { get; set; }
        public bool Ais { get; set; }
        public bool Radar { get; set; }
        public bool Plotter { get; set; }
        public bool BowThruster { get; set; }
        public bool FishingEquipment { get; set; }
        public bool Freezer { get; set; }
        public bool Generator { get; set; }
        public bool Insurance { get; set; }
        public bool SmartTv { get; set; }
        public bool TeakCockpit { get; set; }
        public bool ElectricWinches { get; set; }
        public bool FishingPad { get; set; }
        public bool Fridge { get; set; }
        public bool Jacuzzi { get; set; }
        public bool WaterMaker { get; set; }
        public bool Bimini { get; set; }
        public bool Dinghy { get; set; }
        public bool Snorkel { get; set; }
        public bool StandUpPaddle { get; set; }
        public bool CoffeMachine { get; set; }
        public bool RadioCd { get; set; }
        public bool OutboardEngine { get; set; }
        public string? Extras { get; set; }
    }
}