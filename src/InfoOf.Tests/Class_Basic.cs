using System;

namespace Tests {
    public record Class_Basic {
        public string Source_Name { get; init; } = string.Empty;
        public string Dest_Name { get; init; } = string.Empty;

        public DateTimeOffset? Source_Date { get; init; }
        public DateTimeOffset? Dest_Date { get; init; }

    }

}