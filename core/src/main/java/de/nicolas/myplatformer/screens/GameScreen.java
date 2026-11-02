package de.nicolas.myplatformer.screens;

import com.badlogic.gdx.ScreenAdapter;
import com.badlogic.gdx.assets.AssetManager;
import com.badlogic.gdx.graphics.Color;
import com.badlogic.gdx.graphics.OrthographicCamera;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.utils.ScreenUtils;
import com.badlogic.gdx.utils.viewport.Viewport;
import de.nicolas.myplatformer.MyGame;

public class GameScreen extends ScreenAdapter {

    /**
     * Verweis auf die Game-Klasse für den Zugriff auf
     * Spritebatch und AssetManager
     */
    private final MyGame game;
    private final SpriteBatch batch;
    private final AssetManager assetManager;

    /** die Hauptkamera und der entsprechende Viewport des Spiels **/
    private final OrthographicCamera gameCam;
    private final Viewport gameViewport;

    public GameScreen(MyGame game) {

        this.game = game;
    }

    @Override
    public void render(float delta) {

        ScreenUtils.clear(Color.BLACK);
    }
}
