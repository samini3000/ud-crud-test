﻿namespace FRD.Domain
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
        
    }
}
