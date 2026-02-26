namespace DiceService.DataObject;

public record DiceResultInfo(
	int Result,
	RollMode Mode,
	int FirstDice,
	int SecondDice);
