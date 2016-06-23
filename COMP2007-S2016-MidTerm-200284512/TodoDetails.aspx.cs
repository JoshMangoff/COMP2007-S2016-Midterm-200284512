using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//allow db connection
using COMP2007_S2016_MidTerm_200284512.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic; 

/**
 * Author: Josh Mangoff
 * Student #: 200284512
 * Date Modified: June 23, 2016
 * Version: 0.0.2 - always new instead of update but replaces all placeholders except checkbox
 * Description: Unmodified .cs file of TodoDetails page
 */

namespace COMP2007_S2016_MidTerm_200284512
{
    public partial class TodoDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //check if update or new
            if((!IsPostBack) && (Request.QueryString.Count == 0))
            {
                //load todo
                this.GetTodo();
            }
        }

        /**
         * <summary>
         * Checks if is an old todo and replaces placeholders
         * </summary>
         * @method GetTodo
         * @returns {void}
         */
        protected void GetTodo()
        {
            //find old todo id
            int TodoID = Convert.ToInt32(Request.QueryString["TodoID"]);

            //connect to db
            using (TodoConnection db = new TodoConnection())
            {
                //add info to variable
                Todo updateTodo = (from todo in db.Todos where todo.TodoID == TodoID select todo).FirstOrDefault();

                //replace placeholders
                if(updateTodo != null)
                {
                    TodoNameTextBox.Text = updateTodo.TodoName;
                    NotesTextBox.Text = updateTodo.TodoNotes;
                }
            }
        }

        /**
         * <summary>
         * Adds data to database
         * </summary>
         * @method SaveButton_Click
         * @param {object} sender
         * @param {EventArgs} e
         * @returns {void}
         */
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            //connect to db
            using (TodoConnection db = new TodoConnection())
            {
                //create new todo
                Todo newTodo = new Todo();

                //add info to todo
                newTodo.TodoName = TodoNameTextBox.Text;
                newTodo.TodoNotes = NotesTextBox.Text;
                newTodo.Completed = CheckBox.Checked;

                //add todo to db
                db.Todos.Add(newTodo);

                //save changes
                db.SaveChanges();

                //redirect
                Response.Redirect("~/TodoList.aspx");
            }
        }
    }
}