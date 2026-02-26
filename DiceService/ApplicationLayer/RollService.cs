using DiceService.DataObject;

namespace DiceService.ApplicationLayer;

public class RollService : IRollService
{
	private static readonly Random _random = new Random();

	public Task<RollResponse> Roll(RollRequest request)
	{
		var response = new RollResponse(
			new List<DiceResultInfo>());

		for (int i = 0; i < request.DiceTroughInfos.Count; i++)
		{
			var firstRoll = _random.Next(1, request.DiceTroughInfos[i].DiceCideCount + 1);
			var rollMode = request.DiceTroughInfos[i].Mode;
			switch (rollMode)
			{
				case RollMode.Normal:
					response.DiceResultInfos.Add(new DiceResultInfo(
						firstRoll,
						rollMode,
						firstRoll,
						firstRoll));
					continue;
				case RollMode.Advantage:
				case RollMode.Disadvantage:
					var secondRoll = _random.Next(1, request.DiceTroughInfos[i].DiceCideCount + 1);
					response.DiceResultInfos.Add(new DiceResultInfo(
						rollMode == RollMode.Advantage ?
							Math.Max(firstRoll, secondRoll) :
							Math.Min(firstRoll, secondRoll),
						rollMode,
						firstRoll,
						firstRoll));

					continue;
				default:
					throw new NotImplementedException("Not existing diceMode");
					continue;

			}
		}

		return Task.FromResult(response);
	}
}
