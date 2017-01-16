using System;
using System.Collections.Generic;
using D3arDiablo.Build;

namespace D3arDiablo.ViewModel
{
  public class BuildViewModel : ViewModelBase
  {
    private IBuild _build;
    private IDictionary<Slot, ItemViewModel> _itemViewModels;

    public BuildViewModel(IBuild build)
    {
      _build = build;
      _itemViewModels = new Dictionary<Slot, ItemViewModel>();
      foreach (Slot s in Enum.GetValues(typeof(Slot)))
      {
        _itemViewModels[s] = new ItemViewModel(_build.GetItem(s));
      }
    }

    public IDictionary<Slot, ItemViewModel> ItemViewModels
    {
      get { return _itemViewModels; }
    }

    public ItemViewModel Shoulder
    {
      get { return _itemViewModels[Slot.Shoulder]; }
    }
    public ItemViewModel Hands
    {
      get { return _itemViewModels[Slot.Hands]; }
    }
    public ItemViewModel MainFinger
    {
      get { return _itemViewModels[Slot.MainFinger]; }
    }
    public ItemViewModel MainHand
    {
      get { return _itemViewModels[Slot.MainHand]; }
    }
    public ItemViewModel CubeWeapon
    {
      get { return _itemViewModels[Slot.CubeWeapon]; }
    }
    public ItemViewModel Head
    {
      get { return _itemViewModels[Slot.Head]; }
    }
    public ItemViewModel Torso
    {
      get { return _itemViewModels[Slot.Torso]; }
    }
    public ItemViewModel Waist
    {
      get { return _itemViewModels[Slot.Waist]; }
    }
    public ItemViewModel Legs
    {
      get { return _itemViewModels[Slot.Legs]; }
    }
    public ItemViewModel Feet
    {
      get { return _itemViewModels[Slot.Feet]; }
    }
    public ItemViewModel CubeArmor
    {
      get { return _itemViewModels[Slot.CubeArmor]; }
    }
    public ItemViewModel Neck
    {
      get { return _itemViewModels[Slot.Neck]; }
    }
    public ItemViewModel Wrist
    {
      get { return _itemViewModels[Slot.Wrist]; }
    }
    public ItemViewModel OffFinger
    {
      get { return _itemViewModels[Slot.OffFinger]; }
    }
    public ItemViewModel OffHand
    {
      get { return _itemViewModels[Slot.OffHand]; }
    }
    public ItemViewModel CubeJewelry
    {
      get { return _itemViewModels[Slot.CubeJewelry]; }
    }
  }
}
