namespace DiceService.DataObject;

public record RollResponse(
	IList<DiceResultInfo> DiceResultInfos);
