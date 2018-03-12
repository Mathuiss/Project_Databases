using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using Data;

namespace Logic
{
    public class AfrekenProcessor
    {
        public void RekenAf(ListView.CheckedListViewItemCollection checkedItems, int aantal)
        {
            var voorraad = new List<VoorraadObject>();

            foreach (ListViewItem item in checkedItems)
            {
                int id = Utils.GetId("VOORRAAD", "where naam like '" + item.Text.Replace(" ", "") + "'");
                voorraad.Add(new VoorraadObject(id, item.Text, aantal));
            }
        }
    }
}
