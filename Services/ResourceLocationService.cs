﻿using AzNamingTool.Helpers;
using AzNamingTool.Models;

namespace AzNamingTool.Services
{
    public class ResourceLocationService
    {
        private static ServiceResponse serviceResponse = new();

        public static async Task<ServiceResponse> GetItems()
        {
            try
            {
                // Get list of items
                var items = await GeneralHelper.GetList<ResourceLocation>();
                serviceResponse.ResponseObject = items;
                serviceResponse.Success = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.ResponseObject = ex;
            }
            return serviceResponse;
        }
        public static async Task<ServiceResponse> GetItem(int id)
        {
            try
            {
                // Get list of items
                var data = await GeneralHelper.GetList<ResourceLocation>();
                var item = data.Find(x => x.Id == id);
                serviceResponse.ResponseObject = item;
                serviceResponse.Success = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.ResponseObject = ex;
            }
            return serviceResponse;
        }
        //public static async Task<ServiceResponse> PostItem(ResourceLocation item)
        //{
        //    try
        //    {
        //        // Make sure the new item short name only contains letters/numbers
        //        if (!GeneralHelper.CheckAlphanumeric(item.ShortName))
        //        {
        //            serviceResponse.Success = false;
        //            serviceResponse.ResponseObject = "Short name must be alphanumeric.";
        //            return serviceResponse;
        //        }


        //        // Get list of items
        //        var items = await GeneralHelper.GetList<ResourceLocation>();

        //        // Set the new id
        //        if (item.Id == 0)
        //        {
        //            item.Id = items.Count + 1;
        //        }

        //        items = items.OrderBy(x => x.Name).ToList();

        //        // Determine new item id
        //        if (items.Count > 0)
        //        {
        //            // Check if the item already exists
        //            if (items.Exists(x => x.Id == item.Id))
        //            {
        //                // Remove the updated item from the list
        //                var existingitem = items.Find(x => x.Id == item.Id);
        //                int index = items.IndexOf(existingitem);
        //                items.RemoveAt(index);
        //            }
        //            {
        //                // Put the item at the end
        //                items.Add(item);
        //            }
        //        }
        //        else
        //        {
        //            item.Id = 1;
        //            items.Add(item);
        //        }

        //        // Write items to file
        //        await GeneralHelper.WriteList<ResourceLocation>(items);
        //        serviceResponse.Success = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        serviceResponse.ResponseObject = ex;
        //        serviceResponse.Success = false;
        //    }
        //    return serviceResponse;
        //}

        //public static async Task<ServiceResponse> DeleteItem(int id)
        //{
        //    try
        //    {
        //        // Get list of items
        //        var items = await GeneralHelper.GetList<ResourceLocation>();
        //        // Get the specified item
        //        var item = items.Find(x => x.Id == id);
        //        // Remove the item from the collection
        //        items.Remove(item);

        //        // Write items to file
        //        await GeneralHelper.WriteList<ResourceLocation>(items);
        //        serviceResponse.Success = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        serviceResponse.ResponseObject = ex;
        //        serviceResponse.Success = false;
        //    }
        //    return serviceResponse;
        //}

        public static async Task<ServiceResponse> PostConfig(List<ResourceLocation> items)
        {
            try
            {
                // Get list of items
                var newitems = new List<ResourceLocation>();
                int i = 1;

                // Determine new item id
                foreach (ResourceLocation item in items)
                {
                    // Make sure the new item short name only contains letters/numbers
                    if (!GeneralHelper.CheckAlphanumeric(item.ShortName))
                    {
                        serviceResponse.Success = false;
                        serviceResponse.ResponseObject = "Short name must be alphanumeric.";
                        return serviceResponse;
                    }
                    item.Id = i;
                    newitems.Add(item);
                    i += 1;
                }

                // Write items to file
                await GeneralHelper.WriteList<ResourceLocation>(newitems);
                serviceResponse.Success = true;
            }
            catch (Exception ex)
            {
                serviceResponse.ResponseObject = ex;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }
    }
}
