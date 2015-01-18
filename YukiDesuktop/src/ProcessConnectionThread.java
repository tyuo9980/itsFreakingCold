import java.awt.Robot;
import java.awt.event.KeyEvent;
import java.io.InputStream;

import javax.microedition.io.StreamConnection;

public class ProcessConnectionThread implements Runnable
{

	private StreamConnection mConnection;

	// Constant that indicate command from devices
	private static final int EXIT_CMD = -1;
	private static final int KEY_RIGHT = 1;
	private static final int KEY_LEFT = 2;

	public static final int LAND_R = 5;
	public static final int LAND_L = 6;
	public static final int THROW = 7;

	public ProcessConnectionThread(StreamConnection connection)
	{
		mConnection = connection;
	}

	@Override
	public void run()
	{
		try
		{

			// prepare to receive data
			InputStream inputStream = mConnection.openInputStream();

			System.out.println("waiting for input");

			while (true)
			{
				int command = inputStream.read();

				if (command == EXIT_CMD)
				{
					System.out.println("finish process");
					break;
				}

				processCommand(command);
			}
		} catch (Exception e)
		{
			e.printStackTrace();
		}
	}

	/**
	 * Process the command from client
	 * 
	 * @param command
	 *            the command code
	 */
	private void processCommand(int command)
	{
		try
		{
			Robot robot = new Robot();
			switch (command)
			{
				case KEY_RIGHT:
					robot.keyPress(KeyEvent.VK_RIGHT);
					System.out.println("Right");
					// release the key after it is pressed. Otherwise the event just keeps getting trigged
					robot.keyRelease(KeyEvent.VK_RIGHT);
					break;
				case KEY_LEFT:
					robot.keyPress(KeyEvent.VK_LEFT);
					System.out.println("Left");
					// release the key after it is pressed. Otherwise the event just keeps getting trigged
					robot.keyRelease(KeyEvent.VK_LEFT);
					break;
				case LAND_R:
					robot.keyPress(KeyEvent.VK_D);
					robot.keyPress(KeyEvent.VK_D);
					System.out.println("move right");
					
					break;
				case LAND_L:
					robot.keyPress(KeyEvent.VK_A);
					robot.keyPress(KeyEvent.VK_A);
					System.out.println("move left");
					
					break;
				case THROW:
					robot.keyPress(KeyEvent.VK_E);
					robot.keyPress(KeyEvent.VK_E);
					System.out.println("throw");
					
					break;
			}

		} catch (Exception e)
		{
			e.printStackTrace();
		}
	}
}
