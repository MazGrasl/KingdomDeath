public static class SettlementResourceStorageItemMapper {
    public static SettlementResourceStorageItem toItem(SettlementResourceStorageItemDTO itemDTO, Resource resource) {
        return new SettlementResourceStorageItem {
            SettlementId = itemDTO.SettlementId,
            Amount = itemDTO.Amount,
            ResourceId = itemDTO.ResourceId,
            Resource = resource,
        };
    }

    public static SettlementResourceStorageItemDTO toDTO(SettlementResourceStorageItem item) {
        return new SettlementResourceStorageItemDTO {
            SettlementId = item.SettlementId,
            Amount = item.Amount,
            ResourceId = item.ResourceId,
            ResourceName = item.Resource.Name,
        };
    }
}