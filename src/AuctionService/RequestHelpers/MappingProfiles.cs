using AuctionService.DTOs;
using AuctionService.Entities;
using AutoMapper;

namespace AuctionService.RequestHelpers;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        //From source to destination mapping
        //since Auction class has navigation properties
        //for Item class, we need to include it as a member in the below mapping
        CreateMap<Auction, AuctionDto>().IncludeMembers(x => x.Item);

        //Since we combining all the data into one Dto (AuctionDto) and returning it.
        CreateMap<Item, AuctionDto>();

        //We will use Dto to get data from client and map it to Auction class,
        //and then we need to map this dto to Item class as well as both tables have relationship
        //Source represents Item in this case
        CreateMap<CreateAuctionDto, Auction>()
            .ForMember(destination => destination.Item, options => options.MapFrom(source => source));

        //Same as above
        CreateMap<CreateAuctionDto, Item>();
    }
}
