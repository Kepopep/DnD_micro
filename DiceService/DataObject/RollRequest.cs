namespace DiceService.DataObject;

public record RollRequest(
	IList<DiceTroughInfo> DiceTroughInfos);
