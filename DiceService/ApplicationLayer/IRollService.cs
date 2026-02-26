using DiceService.DataObject;

namespace DiceService.ApplicationLayer;

public interface IRollService
{
	public Task<RollResponse> Roll(RollRequest request);
}
