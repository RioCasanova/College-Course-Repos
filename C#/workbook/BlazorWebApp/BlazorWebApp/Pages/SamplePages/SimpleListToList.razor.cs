﻿using Microsoft.AspNetCore.Components;
using PlaylistManagementSystem.BLL;
using PlaylistManagementSystem.ViewModels;

namespace BlazorWebApp.Pages.SamplePages
{
    public partial class SimpleListToList
    {
        [Inject]
        protected PlaylistManagementService? PlaylistManagementService { get; set; }

        #region Fields

        //  list of our current available songs
        private List<ExtendedTrackSelectionView> inventory { get; set; }
        //  shopping cart
        private List<ExtendedTrackSelectionView> shoppingCart { get; set; } = new();
        #endregion

        //  page load and retrieving inventory
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            inventory = PlaylistManagementService.FetchInventory();
        }

        //  add tracks from inventory to shopping cart
        private async Task AddTrackToCart(int trackId)
        {
            ExtendedTrackSelectionView track = inventory
                                                .Where(x => x.TrackId == trackId)
                                                .Select(x => x)
                                                .FirstOrDefault();
            shoppingCart.Add(track);
            inventory.Remove(track);
            await InvokeAsync(StateHasChanged);
        }

        //  remove tracks from shopping cart and add it back to the inventory
        public async Task RemoveTrackFromCart(int trackId)
        {
            ExtendedTrackSelectionView track = shoppingCart
                .Where(x => x.TrackId == trackId)
                .Select(x => x)
                .FirstOrDefault();
            track.Quantity = 1;
            track.Total = track.Price;
            inventory.Add(track);
            inventory = inventory.OrderBy(x => x.SongName).Select(x => x).ToList();
            shoppingCart.Remove(track);
            await InvokeAsync(StateHasChanged);
        }

        // calculate total
        private async Task RefreshTotal(int trackId)
        {
            ExtendedTrackSelectionView track = shoppingCart
                .Where(x => x.TrackId == trackId)
                .Select(x => x)
                .FirstOrDefault();
            track.Total = track.Price * track.Quantity;
            await InvokeAsync(StateHasChanged);
        }

    }
}
