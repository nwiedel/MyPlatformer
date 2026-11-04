package de.nicolas.myplatformer.utils;

import com.badlogic.gdx.graphics.Color;

public class GameConfig {

    /** Standardhintergrundfarbe */
    public final static Color CORNFLOWER_BLUE = new Color(0.388f, 0.584f, 0.933f, 0.0f);

    /** Fenstergröße des Programms */
    public static final int WINDOW_WIDTH = 800;
    public static final int WINDOW_HEIGHT = 450;

    /** HUD Größe entspricht der Fenstergröße */
    public static final int HUD_WIDTH = WINDOW_WIDTH;
    public static final int HUD_HEIGHT = WINDOW_HEIGHT;

    /** Spielewelt größe und die größe einer Einheit*/
    public static final float WORLD_WIDTH = 32f;
    public static final float WORLD_HEIGHT = 18f;
    public static final float UNIT_SCALE = 1f / 16f;
}
