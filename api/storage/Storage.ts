import {ImageOrientation, ImageResolution} from '../../interfaces';

const host = process.env.STORAGE_HOST || 'http://localhost:3000';

/* tslint:disable:max-classes-per-file */
export default class Storage {
    public static Static = class {
        public static Icons = class {
            public static Elwark = class {
                public static Primary = class {
                    public static Size16x16 = `${host}/static/icons/elwark/primary/16x16.png`;
                    public static Size32x32 = `${host}/static/icons/elwark/primary/32x32.png`;
                    public static Size36x36 = `${host}/static/icons/elwark/primary/36x36.png`;
                    public static Size48x48 = `${host}/static/icons/elwark/primary/48x48.png`;
                    public static Size57x57 = `${host}/static/icons/elwark/primary/57x57.png`;
                    public static Size60x60 = `${host}/static/icons/elwark/primary/60x60.png`;
                    public static Size70x70 = `${host}/static/icons/elwark/primary/70x70.png`;
                    public static Size72x72 = `${host}/static/icons/elwark/primary/72x72.png`;
                    public static Size76x76 = `${host}/static/icons/elwark/primary/76x76.png`;
                    public static Size96x96 = `${host}/static/icons/elwark/primary/96x96.png`;
                    public static Size114x114 = `${host}/static/icons/elwark/primary/114x114.png`;
                    public static Size120x120 = `${host}/static/icons/elwark/primary/120x120.png`;
                    public static Size144x144 = `${host}/static/icons/elwark/primary/144x144.png`;
                    public static Size150x150 = `${host}/static/icons/elwark/primary/150x150.png`;
                    public static Size152x152 = `${host}/static/icons/elwark/primary/152x152.png`;
                    public static Size180x180 = `${host}/static/icons/elwark/primary/180x180.png`;
                    public static Size192x192 = `${host}/static/icons/elwark/primary/192x192.png`;
                    public static Size310x310 = `${host}/static/icons/elwark/primary/310x310.png`;
                    public static Favicon = `${host}/static/icons/elwark/primary/favicon.ico`;
                };

                public static White = class {
                    public static Size16x16 = `${host}/static/icons/elwark/white/16x16.png`;
                    public static Size32x32 = `${host}/static/icons/elwark/white/32x32.png`;
                    public static Size36x36 = `${host}/static/icons/elwark/white/36x36.png`;
                    public static Size48x48 = `${host}/static/icons/elwark/white/48x48.png`;
                    public static Size57x57 = `${host}/static/icons/elwark/white/57x57.png`;
                    public static Size60x60 = `${host}/static/icons/elwark/white/60x60.png`;
                    public static Size70x70 = `${host}/static/icons/elwark/white/70x70.png`;
                    public static Size72x72 = `${host}/static/icons/elwark/white/72x72.png`;
                    public static Size76x76 = `${host}/static/icons/elwark/white/76x76.png`;
                    public static Size96x96 = `${host}/static/icons/elwark/white/96x96.png`;
                    public static Size114x114 = `${host}/static/icons/elwark/white/114x114.png`;
                    public static Size120x120 = `${host}/static/icons/elwark/white/120x120.png`;
                    public static Size144x144 = `${host}/static/icons/elwark/white/144x144.png`;
                    public static Size150x150 = `${host}/static/icons/elwark/white/150x150.png`;
                    public static Size152x152 = `${host}/static/icons/elwark/white/152x152.png`;
                    public static Size180x180 = `${host}/static/icons/elwark/white/180x180.png`;
                    public static Size192x192 = `${host}/static/icons/elwark/white/192x192.png`;
                    public static Size310x310 = `${host}/static/icons/elwark/white/310x310.png`;
                    public static Favicon = `${host}/static/icons/elwark/white/favicon.ico`;
                };
            };
        };
    };

    public static Images = class {
        public static RandomByImageResolution(name: ImageResolution,
                                              orientation: ImageOrientation = ImageOrientation.Landscape) {
            return `${host}/images/random/${name}?orientation=${orientation}`;
        }
    };
}
