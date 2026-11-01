package de.nicolas.myplatformer.screens;

import com.badlogic.gdx.ScreenAdapter;
import com.badlogic.gdx.graphics.Color;
import com.badlogic.gdx.utils.ScreenUtils;
import de.nicolas.myplatformer.MyGame;

public class GameScreen extends ScreenAdapter {

    private final MyGame game;

    public GameScreen(MyGame game) {

        this.game = game;
    }

    @Override
    public void render(float delta) {

        ScreenUtils.clear(Color.BLACK);
    }
}
