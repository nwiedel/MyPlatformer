package de.nicolas.myplatformer;

import com.badlogic.gdx.Application;
import com.badlogic.gdx.Game;
import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.InputMultiplexer;
import com.badlogic.gdx.assets.AssetManager;
import com.badlogic.gdx.graphics.FPSLogger;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.graphics.profiling.GLProfiler;
import com.badlogic.gdx.utils.ScreenUtils;
import de.nicolas.myplatformer.screens.LoadingScreen;

public class MyGame extends Game {

    /** der globale AssetManager */
    private AssetManager assetManager;

    /** der globale Pinsel */
    private SpriteBatch batch;

    /** Überwachung für unser Program */
    private GLProfiler glProfiler;
    private FPSLogger fpsLogger;

    /** Input Steuerung */
    private InputMultiplexer inputMultiplexer;

    @Override
    public void create() {
        Gdx.app.setLogLevel(Application.LOG_DEBUG);

        inputMultiplexer = new InputMultiplexer();
        Gdx.input.setInputProcessor(inputMultiplexer);

        batch = new SpriteBatch();
        assetManager = new AssetManager();

        glProfiler = new GLProfiler(Gdx.graphics);
        glProfiler.enable();
        fpsLogger = new FPSLogger();

        setScreen(new LoadingScreen(this));
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
        batch.dispose();
        assetManager.dispose();
    }
}
