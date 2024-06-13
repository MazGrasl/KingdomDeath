public static class SettlementGearStorageItemMapper {
    public static SettlementGearStorageItem toItem(SettlementGearStorageItemDTO itemDTO, Gear gear) {
        return new SettlementGearStorageItem {
            SettlementId = itemDTO.SettlementId,
            Amount = itemDTO.Amount,
            GearId = itemDTO.GearId,
            Gear = gear
        };
    }

    public static SettlementGearStorageItemDTO toDTO(SettlementGearStorageItem item) {
        return new SettlementGearStorageItemDTO {
            SettlementId = item.SettlementId,
            Amount = item.Amount,
            GearId = item.GearId,
            GearName = item.Gear.Name,
        };
    }
}
