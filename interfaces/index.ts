export interface CompanyModel {
    id: number;
    name: string;
    description: string;
    logotype: CompanyLogotype;
    sites: Record<string, string>;
    contacts: Record<string, string>;
}

export interface CompanyShortModel {
    id: number;
    name: string;
    logotype: CompanyLogotype;
}

export interface CompanyLogotype {
    square: string;
    rectangle: string;
}

export interface CompanyStats {
    rating: number;
    cafeCount: number;
}

export enum ImageOrientation {
    Landscape = 'landscape',
    Portrait = 'portrait',
}

export enum ImageResolution {
    VGA = 'vga',
    SVGA = 'svga',
    XGA = 'xga',
    HD = 'hd',
    WHD = 'whd',
    WXGAplus = 'wxgaplus',
    HDplus = 'hdplus',
    FHD = 'fhd',
    QHD = 'qhd',
    UHD = 'uhd',
}
