﻿using Library.Utils.Visitor;

namespace Library.Models;

public abstract class AbstractElem
{
    public int Id { get; set; }
    public String title { get; set; }
    public DateTime? returnDate { get; set; }
    public Member borrowedBy { get; set; }
    
    protected AbstractElem () {}
    
    protected AbstractElem (string? title)
    {
        this.title = title;
    }
    
    public abstract void Accept(Show visitor);
}