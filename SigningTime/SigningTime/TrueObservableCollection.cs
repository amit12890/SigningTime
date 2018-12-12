using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

/// <summary>
/// ObservableCollection doesn't raise an event when one of the items it contains
/// is changed, but only when the collection itself changes (an item is added, 
/// removed, etc.), so this class should help mitigate that problem.
/// 
/// Source skeleton code found here: https://stackoverflow.com/a/5256827
/// </summary>
public sealed class TrulyObservableCollection<T> : ObservableCollection<T>
    where T : INotifyPropertyChanged
{
    public TrulyObservableCollection()
    {
        CollectionChanged += FullObservableCollectionCollectionChanged;
    }

    public TrulyObservableCollection(IEnumerable<T> pItems) : this()
    {
        foreach (var item in pItems)
        {
            this.Add(item);
        }
    }

    private void FullObservableCollectionCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems != null)
        {
            foreach (Object item in e.NewItems)
            {
                ((INotifyPropertyChanged)item).PropertyChanged += ItemPropertyChanged;
            }
        }
        if (e.OldItems != null)
        {
            foreach (Object item in e.OldItems)
            {
                ((INotifyPropertyChanged)item).PropertyChanged -= ItemPropertyChanged;
            }
        }
    }

    private void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        NotifyCollectionChangedEventArgs args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, sender, sender, IndexOf((T)sender));
        OnCollectionChanged(args);
    }
}