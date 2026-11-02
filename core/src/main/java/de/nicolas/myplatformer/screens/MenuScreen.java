package de.nicolas.myplatformer.screens;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Input;
import com.badlogic.gdx.ScreenAdapter;
import com.badlogic.gdx.graphics.Color;
import com.badlogic.gdx.utils.ScreenUtils;
import de.nicolas.myplatformer.MyGame;

public class MenuScreen extends ScreenAdapter {

    /** Verweis auf die Game Klasse */
    private final MyGame game;

    public MenuScreen(MyGame game) {

        this.game = game;
    }

    @Override
    public void render(float delta) {

        update(delta);

        ScreenUtils.clear(Color.RED);
    }

    private void update(float delta) {

        if (Gdx.input.isKeyJustPressed(Input.Keys.ENTER)){

            game.setScreens(GameScreen.class);
        }
    }


}
