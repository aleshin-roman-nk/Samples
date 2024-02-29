export interface Computer {
    ComputerId: number;
    motherboard: string;
    CPUCores: number;
    hasWifi: boolean;
    HasLTE: boolean;
    releaseDate: Date | null;
    Price: number;
    videoCard: string;
  }