package de.nicolas.myplatformer.screens;

import com.badlogic.gdx.ScreenAdapter;
import com.badlogic.gdx.assets.AssetManager;
import com.badlogic.gdx.graphics.OrthographicCamera;
import com.badlogic.gdx.graphics.glutils.ShapeRenderer;
import com.badlogic.gdx.maps.tiled.TiledMap;
import com.badlogic.gdx.maps.tiled.TmxMapLoader;
import com.badlogic.gdx.utils.ScreenUtils;
import com.badlogic.gdx.utils.viewport.FitViewport;
import com.badlogic.gdx.utils.viewport.Viewport;
import de.nicolas.myplatformer.MyGame;
import de.nicolas.myplatformer.assets.AssetDescriptors;
import de.nicolas.myplatformer.utils.GameConfig;

public class LoadingScreen extends ScreenAdapter {

    /** Verweis auf die Game Klasse */
    private final MyGame game;
    /** Verweis auf den AssetManager */
    private final AssetManager assetManager;

    /** Breite und Höhe des Ladebalken */
    public static final float PROGRESS_BAR_WIDTH = GameConfig.HUD_WIDTH / 2f;
    public static final float PROGRSS_BAR_HEIGHT = 35f;

    /** Fortschritt des Ladebalkens*/
    private float progress;
    /** Wartezeit, um den Ladebalken sichtbar zu machen */
    private float waitTime = 0.75f;
    /** Flag, um den Wechsel des Screens anzustoßen*/
    private boolean changeScreen;

    /** Kamera des LoadingScreens*/
    private OrthographicCamera camera;
    /** Viewport des LoadingScreens*/
    private Viewport viewport;
    /** Pinsel des Ladebalkens */
    private ShapeRenderer shapeRenderer;

    public LoadingScreen(MyGame game) {
        this.game = game;
        assetManager = game.getAssetManager();
    }

    @Override
    public void show() {
        camera = new OrthographicCamera();
        viewport = new FitViewport(GameConfig.HUD_WIDTH, GameConfig.HUD_HEIGHT, camera);
        shapeRenderer = new ShapeRenderer();

        //  TODO Ladevorgänge!
        assetManager.setLoader(TiledMap.class, new TmxMapLoader());
        assetManager.load(AssetDescriptors.LEVEL_1);
    }

    @Override
    public void render(float delta) {

        // updaten des Ladescreens
        update(delta);

        // Screen löschen
        ScreenUtils.clear(GameConfig.CORNFLOWER_BLUE);

        viewport.apply();

        shapeRenderer.setProjectionMatrix(camera.combined);
        shapeRenderer.begin(ShapeRenderer.ShapeType.Filled);
        draw();
        shapeRenderer.end();

        if (changeScreen){
            game.setScreens(MenuScreen.class);
        }
    }

    /** Die Methode sorgt dafür, das nach dem Laden der Assets eine Verzögerung erzeugt wird. */
    private void update(float delta) {

        progress = assetManager.getProgress();

        if (assetManager.update()) {
            waitTime -= delta;
            if (waitTime <= 0){
                changeScreen = true;
            }
        }
    }

    /** Die Methode zeichnet den ProgressBar. */
    private void draw() {

        float progressBarX = (GameConfig.HUD_WIDTH - PROGRESS_BAR_WIDTH) / 2f;
        float progressBarY = (GameConfig.HUD_HEIGHT - PROGRSS_BAR_HEIGHT) / 2f;

        shapeRenderer.rect(progressBarX, progressBarY,
            progress * PROGRESS_BAR_WIDTH, PROGRSS_BAR_HEIGHT);
    }

    @Override
    public void resize(int width, int height) {

        viewport.update(width,height, true);
    }

    @Override
    public void hide() {


    }

    @Override
    public void dispose() {

        shapeRenderer.dispose();
    }
}
