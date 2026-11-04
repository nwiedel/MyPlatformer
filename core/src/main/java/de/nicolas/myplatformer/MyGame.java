package de.nicolas.myplatformer;

import com.badlogic.gdx.*;
import com.badlogic.gdx.assets.AssetManager;
import com.badlogic.gdx.graphics.FPSLogger;
import com.badlogic.gdx.graphics.OrthographicCamera;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.graphics.profiling.GLProfiler;
import com.badlogic.gdx.utils.GdxRuntimeException;
import com.badlogic.gdx.utils.ScreenUtils;
import com.badlogic.gdx.utils.viewport.FitViewport;
import com.badlogic.gdx.utils.viewport.Viewport;
import de.nicolas.myplatformer.screens.GameScreen;
import de.nicolas.myplatformer.screens.LoadingScreen;
import de.nicolas.myplatformer.screens.MenuScreen;
import de.nicolas.myplatformer.utils.GameConfig;

import java.util.HashMap;
import java.util.Map;

public class MyGame extends Game {

    /** der globale AssetManager */
    private AssetManager assetManager;

    /** der globale Pinsel */
    private SpriteBatch batch;

    /** Kameravariablen */
    private OrthographicCamera camera;
    private Viewport viewport;

    /** Überwachung für unser Program */
    private GLProfiler glProfiler;
    private FPSLogger fpsLogger;

    /** Input Steuerung */
    private InputMultiplexer inputMultiplexer;

    /** Liste, die die im Spiel existierenden Screen beinhaltet */
    private final Map<Class<? extends Screen>, Screen> screens = new HashMap<>();

    @Override
    public void create() {
        // setzt Log Level
        Gdx.app.setLogLevel(Application.LOG_DEBUG);

        // initialisiert den Inputprozessor
        inputMultiplexer = new InputMultiplexer();
        Gdx.input.setInputProcessor(inputMultiplexer);

        // Variablen Initialisierung
        batch = new SpriteBatch();
        camera = new OrthographicCamera();
        viewport = new FitViewport(GameConfig.WORLD_WIDTH, GameConfig.WORLD_HEIGHT, camera);
        assetManager = new AssetManager();

        // FPS Überprüfung
        glProfiler = new GLProfiler(Gdx.graphics);
        glProfiler.enable();
        fpsLogger = new FPSLogger();

        // Screen Erstellung
        addScreen(new LoadingScreen(this));
        addScreen(new MenuScreen(this));
        addScreen(new GameScreen(this));


        // Wechsel zum nächsten Screen
        setScreens(LoadingScreen.class);
    }

    @Override
    public void resize(int width, int height) {
        viewport.update(width, height, true);
        super.resize(width, height);
    }

    @Override
    public void render() {
        glProfiler.reset();

        ScreenUtils.clear(0f, 0f, 0f, 1f);

        super.render();

        Gdx.graphics.setTitle("MyPlatformer - Draw Calls: " + glProfiler.getDrawCalls());
        fpsLogger.log();
    }

    @Override
    public void dispose() {
        screens.values().forEach(Screen::dispose);
        screens.clear();

        batch.dispose();
        assetManager.dispose();
    }

    /** Methode, mit der man Screens zur HashMap hinzufügen kann */
    public void addScreen(Screen screen){
        if (screens.containsValue(screen)){
            return;
        }
        screens.put(screen.getClass(), screen);
    }

    /** abgewandelte setScreen-Methode die sich den entsprechenden Screen aus der Map holt */
    public void setScreens(Class<? extends Screen> screenClass){
        Screen screen = screens.get(screenClass);
        if(screen == null){
            throw new GdxRuntimeException("Screen nicht vorhanden; " + screenClass);
        }
        super.setScreen(screen);
    }

    /** Getter */
    public AssetManager getAssetManager() {
        return assetManager;
    }

    public SpriteBatch getBatch() {
        return batch;
    }

    public OrthographicCamera getCamera() {
        return camera;
    }

    public Viewport getViewport() {
        return viewport;
    }
}
