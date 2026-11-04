package de.nicolas.myplatformer.screens;

import com.badlogic.gdx.ScreenAdapter;
import com.badlogic.gdx.assets.AssetManager;
import com.badlogic.gdx.graphics.Color;
import com.badlogic.gdx.graphics.OrthographicCamera;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.maps.tiled.renderers.OrthogonalTiledMapRenderer;
import com.badlogic.gdx.utils.ScreenUtils;
import com.badlogic.gdx.utils.viewport.Viewport;
import de.nicolas.myplatformer.MyGame;
import de.nicolas.myplatformer.assets.AssetDescriptors;
import de.nicolas.myplatformer.utils.GameConfig;

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

    /** Zeichnet die Map */
    private final OrthogonalTiledMapRenderer mapRenderer;

    public GameScreen(MyGame game) {

        this.game = game;
        batch = game.getBatch();
        assetManager = game.getAssetManager();

        gameCam = game.getCamera();
        gameViewport = game.getViewport();

        mapRenderer = new OrthogonalTiledMapRenderer(null, GameConfig.UNIT_SCALE, batch);
    }

    @Override
    public void show() {

       mapRenderer.setMap(assetManager.get(AssetDescriptors.LEVEL_1));
    }

    @Override
    public void render(float delta) {

        ScreenUtils.clear(Color.BLACK);

        gameViewport.apply();
        batch.setColor(Color.WHITE);
        mapRenderer.setView(gameCam);
        mapRenderer.render();
    }

    @Override
    public void dispose() {
        mapRenderer.dispose();
    }
}
