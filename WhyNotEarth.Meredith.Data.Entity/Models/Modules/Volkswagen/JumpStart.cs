﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WhyNotEarth.Meredith.Data.Entity.Models.Modules.Volkswagen
{
    public class JumpStart : IEntityTypeConfiguration<JumpStart>
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public List<string> DistributionGroups { get; set; }

        public JumpStartStatus Status { get; set; }

        public bool HasPdf { get; set; }

        public void Configure(EntityTypeBuilder<JumpStart> builder)
        {
            builder.ToTable("JumpStarts", "ModuleVolkswagen");
            builder.Property(b => b.DistributionGroups).IsRequired();
            builder.Property(e => e.DistributionGroups)
                .HasConversion(
                    v => string.Join(",", v),
                    v => v.Split(",", StringSplitOptions.None).ToList());
        }
    }

    public enum JumpStartStatus : byte
    {
        Preview = 1,
        Sending = 2,
        Sent = 3
    }
}