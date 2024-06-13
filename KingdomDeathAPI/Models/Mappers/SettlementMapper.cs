public static class SettlementMapper {
    public static Settlement toSettlement(SettlementDTO settlementDTO) {
        return new Settlement {
            Id = settlementDTO.Id,
            Name = settlementDTO.Name,
        };
    }

    public static SettlementDTO toDTO(Settlement settlement) {
        return new SettlementDTO {
            Id = settlement.Id,
            Name = settlement.Name,
            GearStorage = settlement.GearStorage.ToList().ConvertAll(g => SettlementGearStorageItemMapper.toDTO(g)),
            ResourceStorage = settlement.ResourceStorage.ToList().ConvertAll(g => SettlementResourceStorageItemMapper.toDTO(g))
        };
    }
}