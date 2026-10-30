package de.nicolas.myplatformer.assets;

import com.badlogic.gdx.assets.AssetDescriptor;
import com.badlogic.gdx.maps.tiled.TiledMap;

public class AssetDescriptors {

    /** Descriptor der 1. Map */
    public static final AssetDescriptor<TiledMap> LEVEL_1 =
        new AssetDescriptor<>(AssetLocations.MAP_1, TiledMap.class);
}
