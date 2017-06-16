using System.Collections.Generic;
using XimoSample.Queries.Dtos;

namespace XimoSample.Queries.Responses
{
    public class GetAccountDetailsByIdResponse
    {
        private GetAccountDetailsByIdResponse()
        {
        }

        public GetAccountDetailsByIdResponse(AccountDetailsDto accountDetailsDto, IEnumerable<SystemTagDto> systemTags)
            : this()
        {
            AccountDetailsDto = accountDetailsDto;
            SystemTags = systemTags;
        }

        public AccountDetailsDto AccountDetailsDto { get; }
        public IEnumerable<SystemTagDto> SystemTags { get; }
    }
}